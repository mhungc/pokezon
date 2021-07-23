terraform {
  required_providers {
    azurerm = {
        source = "hashicorp/azurerm"
        version = ">=2.46.0"
    }   
  }
}

# Configure the Microsoft Azure Provider
provider "azurerm" {
  features {}
}

module "webretrofitskaar_rg" {
  source      = "../../modules/resource-group"
  location    = "West Europe"
  resourcegroup_name        = "hp-rg-webretrofitskaar-q"
  environment = "rg-qa"
}

module "webretrofitskaar_asp" {
  source = "../../modules/app-services-plan"
  serviceplan_name          = "hp-asp-webretrofitskaar-q"
  location                  = "West Europe"
  resourcegroup_name        = module.webretrofitskaar_rg.resource_group.name
  environment               = "asp-qa"    
}

module "webretrofitskaar_webapp" {
  source = "../../modules/app-service-webapp"
  azurerm_app_service_name = "hp-api-webretrofitskaar-q"
  serviceplan_name          = "hp-api-webretrofitskaar-q"
  location                  = "West Europe"
  resourcegroup_name        = module.webretrofitskaar_rg.resource_group.name
  environment               = "webapp-qa"    
}

module "webretrofitskaar_asp_sqlserver"{
  source                      = "../../modules/sql-server"
  resourcegroup_name          = module.webretrofitskaar_rg.resource_group.name
  sqlserver_name              = "hp-sqlsv-webretrofitskaar-q"
  location                    = "West Europe"
  azurerm_storage_account_name = "hpsawebretrofitskaarq"
  environment               = "sql-qa"    
}

