variable "environment" {
    type = string
    description = "Tag environment"
    default = "development"
}

variable "resourcegroup_name" {
    
    type = string
    description = "hp-rg-webretrofitskaar-q"
    default = "rg-"
}

variable "location" {
    type= string
    description = "location for the resources"
    default = "West Europe"
}

variable "serviceplan_name" {
   type = string
    description = ""
    default = "rg-"
}