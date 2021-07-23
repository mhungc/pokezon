variable "environment" {
    type = string
    description = "Tag environment"
    default = "development"
}

variable "azurerm_app_service_name" {
    
    type = string
    description = ""
    default = "azurerm_app_service_name"
}

variable "app_service_plan_id" {
    type = string
    description = ""
    default = "app_service_plan_id"
}

variable "location" {
    type= string
    description = "location for the resources"
    default = "West Europe"
}

variable "database_name"{
    type = string
    description = ""
    default = "database_name"
}

variable "database_type"{
    type = string
    description = ""
    default = "database_type-"
}

variable "database_connectionstring"{
    type = string
    description = ""
    default = "database_connectionstring"
}