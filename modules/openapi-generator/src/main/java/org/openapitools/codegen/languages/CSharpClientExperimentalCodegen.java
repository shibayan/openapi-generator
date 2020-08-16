/*
 * Copyright 2018 OpenAPI-Generator Contributors (https://openapi-generator.tech)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     https://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

package org.openapitools.codegen.languages;

import com.google.common.collect.ImmutableMap;
import com.samskivert.mustache.Mustache;
import io.swagger.v3.oas.models.media.ArraySchema;
import io.swagger.v3.oas.models.media.Schema;
import org.openapitools.codegen.*;
import org.openapitools.codegen.meta.features.*;
import org.openapitools.codegen.utils.ModelUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.io.File;
import java.util.*;
import java.util.concurrent.atomic.AtomicReference;
import java.util.function.Consumer;

import static org.apache.commons.lang3.StringUtils.isEmpty;
import static org.openapitools.codegen.utils.StringUtils.camelize;
import static org.openapitools.codegen.utils.StringUtils.underscore;

@SuppressWarnings("Duplicates")
public class CSharpClientExperimentalCodegen extends AbstractCSharpExperimentalCodegen {

    @SuppressWarnings({"hiding"})
    private static final Logger LOGGER = LoggerFactory.getLogger(CSharpClientExperimentalCodegen.class);
    private static final List<FrameworkStrategy> frameworkStrategies = Arrays.asList(
            FrameworkStrategy.NETSTANDARD_2_1,
            FrameworkStrategy.NETCOREAPP_2_1,
            FrameworkStrategy.NETCOREAPP_3_1,
            FrameworkStrategy.NET_5_0
    );
    private static FrameworkStrategy defaultFramework = FrameworkStrategy.NETSTANDARD_2_1;
    protected final Map<String, String> frameworks;
    protected String packageGuid = "{" + java.util.UUID.randomUUID().toString().toUpperCase(Locale.ROOT) + "}";
    protected String clientPackage = "Org.OpenAPITools.Client";
    protected String apiDocPath = "docs/";
    protected String modelDocPath = "docs/";

    // Defines TargetFrameworkVersion in csproj files
    protected String targetFramework = defaultFramework.name;
    protected String testTargetFramework = defaultFramework.testTargetFramework;

    protected boolean validatable = Boolean.TRUE;
    protected Map<Character, String> regexModifiers;

    public CSharpClientExperimentalCodegen() {
        super();

        modifyFeatureSet(features -> features
                .includeDocumentationFeatures(DocumentationFeature.Readme)
                .securityFeatures(EnumSet.of(
                        SecurityFeature.OAuth2_Implicit,
                        SecurityFeature.BasicAuth,
                        SecurityFeature.ApiKey
                ))
                .excludeGlobalFeatures(
                        GlobalFeature.XMLStructureDefinitions,
                        GlobalFeature.Callbacks,
                        GlobalFeature.LinkObjects,
                        GlobalFeature.ParameterStyling
                )
                .includeSchemaSupportFeatures(
                        SchemaSupportFeature.Polymorphism
                )
                .includeClientModificationFeatures(
                        ClientModificationFeature.BasePath,
                        ClientModificationFeature.UserAgent
                )
        );

        hideGenerationTimestamp = Boolean.TRUE;
        supportsInheritance = true;
        modelTemplateFiles.put("model.mustache", ".cs");
        apiTemplateFiles.put("api.mustache", ".cs");
        modelDocTemplateFiles.put("model_doc.mustache", ".md");
        apiDocTemplateFiles.put("api_doc.mustache", ".md");
        embeddedTemplateDir = templateDir = "csharp-experimental";

        cliOptions.clear();

        // CLI options
        addOption(CodegenConstants.PACKAGE_NAME,
                "C# package name (convention: Title.Case).",
                this.packageName);

        addOption(CodegenConstants.PACKAGE_VERSION,
                "C# package version.",
                this.packageVersion);

        addOption(CodegenConstants.SOURCE_FOLDER,
                CodegenConstants.SOURCE_FOLDER_DESC,
                sourceFolder);

        addOption(CodegenConstants.OPTIONAL_PROJECT_GUID,
                CodegenConstants.OPTIONAL_PROJECT_GUID_DESC,
                null);

        addOption(CodegenConstants.LICENSE_ID,
                CodegenConstants.LICENSE_ID_DESC,
                this.licenseId);

        addOption(CodegenConstants.PACKAGE_RELEASE_NOTES,
                CodegenConstants.PACKAGE_RELEASE_NOTES_DESC,
                this.packageReleaseNotes);

        addOption(CodegenConstants.PACKAGE_TAGS,
                CodegenConstants.PACKAGE_TAGS_DESC,
                this.packageTags);

        CliOption framework = new CliOption(
                CodegenConstants.DOTNET_FRAMEWORK,
                CodegenConstants.DOTNET_FRAMEWORK_DESC
        );

        ImmutableMap.Builder<String, String> frameworkBuilder = new ImmutableMap.Builder<>();
        for (FrameworkStrategy frameworkStrategy : frameworkStrategies) {
            frameworkBuilder.put(frameworkStrategy.name, frameworkStrategy.description);
        }

        frameworks = frameworkBuilder.build();

        framework.defaultValue(this.targetFramework);
        framework.setEnum(frameworks);
        cliOptions.add(framework);

        // CLI Switches
        addSwitch(CodegenConstants.HIDE_GENERATION_TIMESTAMP,
                CodegenConstants.HIDE_GENERATION_TIMESTAMP_DESC,
                this.hideGenerationTimestamp);

        addSwitch(CodegenConstants.SORT_PARAMS_BY_REQUIRED_FLAG,
                CodegenConstants.SORT_PARAMS_BY_REQUIRED_FLAG_DESC,
                this.sortParamsByRequiredFlag);

        addSwitch(CodegenConstants.USE_DATETIME_OFFSET,
                CodegenConstants.USE_DATETIME_OFFSET_DESC,
                this.useDateTimeOffsetFlag);

        addSwitch(CodegenConstants.OPTIONAL_PROJECT_FILE,
                CodegenConstants.OPTIONAL_PROJECT_FILE_DESC,
                this.optionalProjectFileFlag);

        addSwitch(CodegenConstants.ALLOW_UNICODE_IDENTIFIERS,
                CodegenConstants.ALLOW_UNICODE_IDENTIFIERS_DESC,
                this.allowUnicodeIdentifiers);

        addSwitch(CodegenConstants.VALIDATABLE,
                CodegenConstants.VALIDATABLE_DESC,
                this.validatable);

        regexModifiers = new HashMap<>();
        regexModifiers.put('i', "IgnoreCase");
        regexModifiers.put('m', "Multiline");
        regexModifiers.put('s', "Singleline");
        regexModifiers.put('x', "IgnorePatternWhitespace");
    }

    @Override
    public String apiDocFileFolder() {
        return (outputFolder + "/" + apiDocPath).replace('/', File.separatorChar);
    }

    @Override
    public String apiTestFileFolder() {
        return outputFolder + File.separator + testFolder + File.separator + testPackageName() + File.separator + apiPackage();
    }

    @Override
    public CodegenModel fromModel(String name, Schema model) {
        Map<String, Schema> allDefinitions = ModelUtils.getSchemas(this.openAPI);
        CodegenModel codegenModel = super.fromModel(name, model);
        if (allDefinitions != null && codegenModel != null && codegenModel.parent != null) {
            final Schema parentModel = allDefinitions.get(toModelName(codegenModel.parent));
            if (parentModel != null) {
                final CodegenModel parentCodegenModel = super.fromModel(codegenModel.parent, parentModel);
                if (codegenModel.hasEnums) {
                    codegenModel = this.reconcileInlineEnums(codegenModel, parentCodegenModel);
                }

                Map<String, CodegenProperty> propertyHash = new HashMap<>(codegenModel.vars.size());
                for (final CodegenProperty property : codegenModel.vars) {
                    propertyHash.put(property.name, property);
                }

                for (final CodegenProperty property : codegenModel.readWriteVars) {
                    if (property.defaultValue == null && parentCodegenModel.discriminator != null && property.baseName.equals(parentCodegenModel.discriminator.getPropertyName())) {
                        property.defaultValue = "\"" + name + "\"";
                    }
                }

                CodegenProperty last = null;
                for (final CodegenProperty property : parentCodegenModel.vars) {
                    // helper list of parentVars simplifies templating
                    if (!propertyHash.containsKey(property.name)) {
                        final CodegenProperty parentVar = property.clone();
                        parentVar.isInherited = true;
                        parentVar.hasMore = true;
                        last = parentVar;
                        LOGGER.debug("adding parent variable {}", property.name);
                        codegenModel.parentVars.add(parentVar);
                    }
                }

                if (last != null) {
                    last.hasMore = false;
                }
            }
        }

        // Cleanup possible duplicates. Currently, readWriteVars can contain the same property twice. May or may not be isolated to C#.
        if (codegenModel != null && codegenModel.readWriteVars != null && codegenModel.readWriteVars.size() > 1) {
            int length = codegenModel.readWriteVars.size() - 1;
            for (int i = length; i > (length / 2); i--) {
                final CodegenProperty codegenProperty = codegenModel.readWriteVars.get(i);
                // If the property at current index is found earlier in the list, remove this last instance.
                if (codegenModel.readWriteVars.indexOf(codegenProperty) < i) {
                    codegenModel.readWriteVars.remove(i);
                }
            }
        }

        return codegenModel;
    }

    @Override
    public String getHelp() {
        return "Generates a C# client library (.NET Standard, .NET Core).";
    }

    @Override
    public String getName() {
        return "csharp-experimental";
    }

    @Override
    public CodegenType getTag() {
        return CodegenType.CLIENT;
    }

    @Override
    public String modelDocFileFolder() {
        return (outputFolder + "/" + modelDocPath).replace('/', File.separatorChar);
    }

    @Override
    public String modelTestFileFolder() {
        return outputFolder + File.separator + testFolder + File.separator + testPackageName() + File.separator + modelPackage();
    }

    @Override
    public void postProcessModelProperty(CodegenModel model, CodegenProperty property) {
        postProcessPattern(property.pattern, property.vendorExtensions);

        super.postProcessModelProperty(model, property);
    }

    @Override
    public Map<String, Object> postProcessOperationsWithModels(Map<String, Object> objs, List<Object> allModels) {
        super.postProcessOperationsWithModels(objs, allModels);
        if (objs != null) {
            Map<String, Object> operations = (Map<String, Object>) objs.get("operations");
            if (operations != null) {
                List<CodegenOperation> ops = (List<CodegenOperation>) operations.get("operation");
                for (CodegenOperation operation : ops) {
                    if (operation.returnType != null) {
                        operation.returnContainer = operation.returnType;
                    }
                }
            }
        }

        return objs;
    }

    @Override
    public void postProcessParameter(CodegenParameter parameter) {
        postProcessPattern(parameter.pattern, parameter.vendorExtensions);

        super.postProcessParameter(parameter);
    }

    /*
     * The pattern spec follows the Perl convention and style of modifiers. .NET
     * does not support this syntax directly so we need to convert the pattern to a .NET compatible
     * format and apply modifiers in a compatible way.
     * See https://msdn.microsoft.com/en-us/library/yd1hzczs(v=vs.110).aspx for .NET options.
     */
    public void postProcessPattern(String pattern, Map<String, Object> vendorExtensions) {
        if (pattern == null) {
            return;
        }

        int i = pattern.lastIndexOf('/');

        //Must follow Perl /pattern/modifiers convention
        if (pattern.charAt(0) != '/' || i < 2) {
            throw new IllegalArgumentException("Pattern must follow the Perl "
                    + "/pattern/modifiers convention. " + pattern + " is not valid.");
        }

        String regex = pattern.substring(1, i).replace("'", "\'");
        List<String> modifiers = new ArrayList<String>();

        // perl requires an explicit modifier to be culture specific and .NET is the reverse.
        modifiers.add("CultureInvariant");

        for (char c : pattern.substring(i).toCharArray()) {
            if (regexModifiers.containsKey(c)) {
                String modifier = regexModifiers.get(c);
                modifiers.add(modifier);
            } else if (c == 'l') {
                modifiers.remove("CultureInvariant");
            }
        }

        vendorExtensions.put("x-regex", regex);
        vendorExtensions.put("x-modifiers", modifiers);
    }

    @Override
    public void processOpts() {
        super.processOpts();

        /*
         * NOTE: When supporting boolean additionalProperties, you should read the value and write it back as a boolean.
         * This avoids oddities where additionalProperties contains "false" rather than false, which will cause the
         * templating engine to behave unexpectedly.
         *
         * Use the pattern:
         *     if (additionalProperties.containsKey(prop)) convertPropertyToBooleanAndWriteBack(prop);
         */

        if (isEmpty(apiPackage)) {
            setApiPackage("Api");
        }
        if (isEmpty(modelPackage)) {
            setModelPackage("Models");
        }
        clientPackage = "Client";

        String framework = (String) additionalProperties.getOrDefault(CodegenConstants.DOTNET_FRAMEWORK, defaultFramework.name);
        FrameworkStrategy strategy = defaultFramework;
        for (FrameworkStrategy frameworkStrategy : frameworkStrategies) {
            if (framework.equals(frameworkStrategy.name)) {
                strategy = frameworkStrategy;
            }
        }

        strategy.configureAdditionalProperties(additionalProperties);

        setTargetFramework(strategy.name);
        setTestTargetFramework(strategy.testTargetFramework);

        final AtomicReference<Boolean> excludeTests = new AtomicReference<>();
        syncBooleanProperty(additionalProperties, CodegenConstants.EXCLUDE_TESTS, excludeTests::set, false);

        syncStringProperty(additionalProperties, "clientPackage", (s) -> { }, clientPackage);

        syncStringProperty(additionalProperties, CodegenConstants.API_PACKAGE, this::setApiPackage, apiPackage);
        syncStringProperty(additionalProperties, CodegenConstants.MODEL_PACKAGE, this::setModelPackage, modelPackage);
        syncStringProperty(additionalProperties, CodegenConstants.OPTIONAL_PROJECT_GUID, this::setPackageGuid, packageGuid);
        syncStringProperty(additionalProperties, "testTargetFramework", this::setTestTargetFramework, this.testTargetFramework);

        syncBooleanProperty(additionalProperties, CodegenConstants.VALIDATABLE, this::setValidatable, this.validatable);
        syncBooleanProperty(additionalProperties, CodegenConstants.OPTIONAL_PROJECT_FILE, this::setOptionalProjectFileFlag, optionalProjectFileFlag);

        final String testPackageName = testPackageName();
        String packageFolder = sourceFolder + File.separator + packageName;
        String clientPackageDir = packageFolder + File.separator + clientPackage;
        String testPackageFolder = testFolder + File.separator + testPackageName;

        additionalProperties.put("testPackageName", testPackageName);

        supportingFiles.add(new SupportingFile("Configuration.mustache", clientPackageDir, "Configuration.cs"));
        supportingFiles.add(new SupportingFile("ApiClient.mustache", clientPackageDir, "ApiClient.cs"));
        supportingFiles.add(new SupportingFile("ApiException.mustache", clientPackageDir, "ApiException.cs"));
        supportingFiles.add(new SupportingFile("ApiResponse.mustache", clientPackageDir, "ApiResponse.cs"));
        supportingFiles.add(new SupportingFile("OpenAPIDateConverter.mustache", clientPackageDir, "OpenAPIDateConverter.cs"));
        supportingFiles.add(new SupportingFile("ClientUtils.mustache", clientPackageDir, "ClientUtils.cs"));
        supportingFiles.add(new SupportingFile("RequestOptions.mustache", clientPackageDir, "RequestOptions.cs"));
        supportingFiles.add(new SupportingFile("Multimap.mustache", clientPackageDir, "Multimap.cs"));

        supportingFiles.add(new SupportingFile("IReadableConfiguration.mustache", clientPackageDir, "IReadableConfiguration.cs"));

        // Only write out test related files if excludeTests is unset or explicitly set to false (see start of this method)
        if (Boolean.FALSE.equals(excludeTests.get())) {
            modelTestTemplateFiles.put("model_test.mustache", ".cs");
            apiTestTemplateFiles.put("api_test.mustache", ".cs");
        }

        supportingFiles.add(new SupportingFile("README.mustache", "", "README.md"));
        supportingFiles.add(new SupportingFile("git_push.sh.mustache", "", "git_push.sh"));
        supportingFiles.add(new SupportingFile("gitignore.mustache", "", ".gitignore"));

        if (optionalProjectFileFlag) {
            supportingFiles.add(new SupportingFile("Solution.mustache", "", packageName + ".sln"));

            supportingFiles.add(new SupportingFile("Project.mustache", packageFolder, packageName + ".csproj"));

            if (Boolean.FALSE.equals(excludeTests.get())) {
                // NOTE: This exists here rather than previous excludeTests block because the test project is considered an optional project file.
                supportingFiles.add(new SupportingFile("TestProject.mustache", testPackageFolder, testPackageName + ".csproj"));
            }
        }

        additionalProperties.put("apiDocPath", apiDocPath);
        additionalProperties.put("modelDocPath", modelDocPath);
    }

    public void setOptionalProjectFileFlag(boolean flag) {
        this.optionalProjectFileFlag = flag;
    }

    public void setPackageGuid(String packageGuid) {
        this.packageGuid = packageGuid;
    }

    public void setTargetFramework(String dotnetFramework) {
        if (!frameworks.containsKey(dotnetFramework)) {
            LOGGER.warn("Invalid .NET Core version, defaulting to " + this.targetFramework);
        } else {
            this.targetFramework = dotnetFramework;
        }
        LOGGER.info("Generating code for .NET Core " + this.targetFramework);
    }

    public void setTestTargetFramework(String testTargetFramework) {
        this.testTargetFramework = testTargetFramework;
    }

    public void setValidatable(boolean validatable) {
        this.validatable = validatable;
    }

    @Override
    public String toEnumVarName(String value, String datatype) {
        if (value.length() == 0) {
            return "Empty";
        }

        // for symbol, e.g. $, #
        if (getSymbolName(value) != null) {
            return camelize(getSymbolName(value));
        }

        // number
        if (datatype.startsWith("int") || datatype.startsWith("long") ||
                datatype.startsWith("double") || datatype.startsWith("float")) {
            String varName = "NUMBER_" + value;
            varName = varName.replaceAll("-", "MINUS_");
            varName = varName.replaceAll("\\+", "PLUS_");
            varName = varName.replaceAll("\\.", "_DOT_");
            return varName;
        }

        // string
        String var = value.replaceAll("_", " ");
        //var = WordUtils.capitalizeFully(var);
        var = camelize(var);
        var = var.replaceAll("\\W+", "");

        if (var.matches("\\d.*")) {
            return "_" + var;
        } else {
            return var;
        }
    }

    private CodegenModel reconcileInlineEnums(CodegenModel codegenModel, CodegenModel parentCodegenModel) {
        // This generator uses inline classes to define enums, which breaks when
        // dealing with models that have subTypes. To clean this up, we will analyze
        // the parent and child models, look for enums that match, and remove
        // them from the child models and leave them in the parent.
        // Because the child models extend the parents, the enums will be available via the parent.

        // Only bother with reconciliation if the parent model has enums.
        if (parentCodegenModel.hasEnums) {

            // Get the properties for the parent and child models
            final List<CodegenProperty> parentModelCodegenProperties = parentCodegenModel.vars;
            List<CodegenProperty> codegenProperties = codegenModel.vars;

            // Iterate over all of the parent model properties
            boolean removedChildEnum = false;
            for (CodegenProperty parentModelCodegenPropery : parentModelCodegenProperties) {
                // Look for enums
                if (parentModelCodegenPropery.isEnum) {
                    // Now that we have found an enum in the parent class,
                    // and search the child class for the same enum.
                    Iterator<CodegenProperty> iterator = codegenProperties.iterator();
                    while (iterator.hasNext()) {
                        CodegenProperty codegenProperty = iterator.next();
                        if (codegenProperty.isEnum && codegenProperty.equals(parentModelCodegenPropery)) {
                            // We found an enum in the child class that is
                            // a duplicate of the one in the parent, so remove it.
                            iterator.remove();
                            removedChildEnum = true;
                        }
                    }
                }
            }

            if (removedChildEnum) {
                // If we removed an entry from this model's vars, we need to ensure hasMore is updated
                int count = 0, numVars = codegenProperties.size();
                for (CodegenProperty codegenProperty : codegenProperties) {
                    count += 1;
                    codegenProperty.hasMore = count < numVars;
                }
                codegenModel.vars = codegenProperties;
            }
        }

        return codegenModel;
    }

    private void syncBooleanProperty(final Map<String, Object> additionalProperties, final String key, final Consumer<Boolean> setter, final Boolean defaultValue) {
        if (additionalProperties.containsKey(key)) {
            setter.accept(convertPropertyToBooleanAndWriteBack(key));
        } else {
            additionalProperties.put(key, defaultValue);
            setter.accept(defaultValue);
        }
    }

    private void syncStringProperty(final Map<String, Object> additionalProperties, final String key, final Consumer<String> setter, final String defaultValue) {
        if (additionalProperties.containsKey(key)) {
            setter.accept((String) additionalProperties.get(key));
        } else {
            additionalProperties.put(key, defaultValue);
            setter.accept(defaultValue);
        }
    }

    // https://docs.microsoft.com/en-us/dotnet/standard/net-standard
    @SuppressWarnings("Duplicates")
    private static abstract class FrameworkStrategy {
        static FrameworkStrategy NETSTANDARD_2_1 = new FrameworkStrategy("netstandard2.1", ".NET Standard 2.1 compatible", "netcoreapp3.1") {
        };
        static FrameworkStrategy NETCOREAPP_2_1 = new FrameworkStrategy("netcoreapp2.1", ".NET Core 2.1 compatible", "netcoreapp2.1") {
        };
        static FrameworkStrategy NETCOREAPP_3_1 = new FrameworkStrategy("netcoreapp3.1", ".NET Core 3.1 compatible", "netcoreapp3.1") {
        };
        static FrameworkStrategy NET_5_0 = new FrameworkStrategy("net5.0", ".NET 5.0 compatible", "net5.0") {
        };
        protected String name;
        protected String description;
        protected String testTargetFramework;

        FrameworkStrategy(String name, String description, String testTargetFramework) {
            this.name = name;
            this.description = description;
            this.testTargetFramework = testTargetFramework;
        }

        protected void configureAdditionalProperties(final Map<String, Object> properties) {
            properties.putIfAbsent(CodegenConstants.DOTNET_FRAMEWORK, this.name);
        }
    }
}
