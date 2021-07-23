resource "azurerm_app_service_plan" "service-plan" {
  name = var.serviceplan_name
  location = var.location
  resource_group_name = var.resourcegroup_name
  kind = "Windows"
  reserved = false
  sku {
    tier = "PremiumV2"
    size = "P1v2"
  }
  tags = {
    environment = var.environment
  }
}