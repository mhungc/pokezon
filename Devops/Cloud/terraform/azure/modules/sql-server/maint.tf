resource "azurerm_storage_account" "example" {
  name                     = var.azurerm_storage_account_name
  resource_group_name      = var.resourcegroup_name
  location                 = var.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
}

resource "azurerm_sql_server" "example" {
  name                         = var.sqlserver_name
  resource_group_name          = var.resourcegroup_name
  location                     = var.location
  version                      = "12.0"
  administrator_login          = "mradministrator"
  administrator_login_password = "thisIsDog11"

  extended_auditing_policy {
    storage_endpoint                        = azurerm_storage_account.example.primary_blob_endpoint
    storage_account_access_key              = azurerm_storage_account.example.primary_access_key
    storage_account_access_key_is_secondary = true
    retention_in_days                       = 6
  }

  tags = {
    environment = var.environment
  }
}


