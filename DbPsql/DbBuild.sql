CREATE DATABASE Raven;

CREATE SCHEMA Materials;
CREATE SCHEMA Distillation;

CREATE TABLE Materials.Material{
    MaterialNumber INT PRIMARY KEY,
    MaterialName VARCHAR(25),
    Binomial VARCHAR(6),
    PermitNumber VARCHAR(25),
    BatchManaged BIT,
    MaterialCode,
    SequenceId,
    MaxSequenceId,
}
CREATE TABLE Materials.MaterialVendor{
    MaterialNumber INT PRIMARY KEY,
    VendorName VARCHAR(25),
    VendorLotNumber VARCHAR(25),
}