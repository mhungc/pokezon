variable "environment" {
    type = string
    description = "Tag environment"
    default = "development"
}

variable "resourcegroup_name" {
    
    type = string
    description = "hp-rg-webretrofitskaar-q"
    default = "hp-rg-webretrofitskaar-q"
}

variable "location" {
    type= string
    description = "location for the resources"
    default = "West Europe"
}

variable "azurerm_storage_account_name"{
    type= string
    description = "storage account name"
    default = ""
}

variable "sqlserver_name"{
    type= string
    description = "sqlserver name"
    default = ""
}