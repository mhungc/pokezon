variable "prefix" {
  description = "A prefix used for all resources in this example"
  default = "pokezonmicro"
}

variable "location" {
  description = "The Azure Region in which all resources in this example should be provisioned"
  default = "West Europe"
}

variable "ssh_public_key" {
    default = "C:/R/pokezon/terraform/keygen.pub"
}

variable "kubernetes_client_id" {
  description = "The Client ID for the Service Principal to use for this Managed Kubernetes Cluster"
  default = "b1d6be0e-7ca7-4f18-bb52-9625889c38a7"
}

variable "kubernetes_client_secret" {
  description = "The Client Secret for the Service Principal to use for this Managed Kubernetes Cluster"
  default = "_Hnrmb_~I7PB9md-RqtZE4j7miFzF~H2ll"
}

variable "azure_subscription_id" {
  description = "The azure subscription"
  default = "a515e1a9-1269-472d-b8d4-d3f93ff1000c"
}

variable "azure_tenenat_tenant_id" {
  description = "The azure Tenant"
  default = "546d3ea0-0c98-475e-83e6-19e2d5a7f293"
}