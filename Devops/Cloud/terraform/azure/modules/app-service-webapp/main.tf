resource "azurerm_app_service" "example" {
  name                = var.azurerm_app_service_name
  location            = var.location
  resource_group_name = var.resource_group_name
  app_service_plan_id = var.app_service_plan_id

  site_config {
    dotnet_framework_version = "v4.0"
    scm_type                 = "LocalGit"
  }

  app_settings = {
    "SOME_KEY" = "some-value"
  }

  connection_string {
    name  = var.database_name
    type  = var.database_type
    value = var.database_connectionstring
  }
}