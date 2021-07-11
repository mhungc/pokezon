terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = ">=2.46.0"
    }
  }
}

# Configure the Microsoft Azure Provider
provider "azurerm" {
  features {}
}

resource "azurerm_resource_group" "rg" {
  name     = "rg-microservicespokezon-dev"
  location = "West Europe"

  tags = {
    environment = "development"
  }
}

resource "azurerm_container_registry" "acr" {
  name                     = "acrpokezondev"
  resource_group_name      = azurerm_resource_group.rg.name
  location                 = azurerm_resource_group.rg.location
  sku                      = "Standard"
  admin_enabled            = false

  tags = {
    environment = "development"
  }
}

resource "azurerm_eventgrid_topic" "aegridt" {
  name                = "egt-pokezonevents"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name

  tags = {
    environment = "development"
  }
}

resource "azurerm_kubernetes_cluster" "aks" {
  name                = "${var.prefix}-k8s"
  location            = "${azurerm_resource_group.rg.location}"
  resource_group_name = "${azurerm_resource_group.rg.name}"
  dns_prefix          = "${var.prefix}-k8s"

  linux_profile {
    admin_username = "ubuntu"

    ssh_key {
            key_data = file(var.ssh_public_key)
        }
  }

    service_principal {
    client_id     = "${var.kubernetes_client_id}"
    client_secret = "${var.kubernetes_client_secret}"
  }

   default_node_pool {
    name       = "default"
    node_count = 1
    vm_size    = "Standard_D2_v2"
  }

  tags = {
    Environment = "development"
  }
}