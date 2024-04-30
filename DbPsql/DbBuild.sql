CREATE DATABASE Raven;

CREATE SCHEMA Materials;
CREATE SCHEMA Distillation;

CREATE TABLE Materials.Material(
    MaterialNumber INT NOT NULL PRIMARY KEY,
    MaterialCode VARCHAR(3) NOT NULL,
    BatchManaged BIT DEFAULT 0::bit NOT NULL,
    SequenceId INT NOT NULL,
    TotalRecords INT NOT NULL,
    UnitOfIssue VARCHAR(3)
)
CREATE TABLE Materials.HighPurityMaterial (
    MaterialNumber INT NOT NULL PRIMARY KEY,
    MaterialName VARCHAR(25) NOT NULL,
    Binomial VARCHAR(6) NOT NULL,
    PermitNumber VARCHAR(25),
    MaterialNumber INT NOT NULL FOREIGN KEY REFERENCES Materials.Material,
);
CREATE TABLE Materials.RawMaterialVendor (
    VendorName VARCHAR(25) NOT NULL PRIMARY KEY,
    VendorLotNumber VARCHAR(25) NOT NULL,
    ContainerNumberRequired BIT DEFAULT 0::BIT NOT NULL,
    MaterialNumber INT NOT NULL FOREIGN KEY REFERENCES Materials.Material,
    ParentMaterialNumber INT NOT NULL FOREIGN KEY REFERENCES Materials.HighPurityMaterial
);
CREATE TABLE Material.RawMaterialLog(
    ProductLotNumber VARCHAR(10) NOT NULL PRIMARY KEY,
    ProductBatchNumber INT,
    VendorName VARCHAR(25),
    VendorLotNumber VARCHAR(25),
    SampleId INT,
    InspectionLotNumber INT,
    ContainerNumber VARCHAR(7),
    NetWeight INT,
    IssueDate DATETIME,
    MaterialNumber INT FOREIGN KEY REFERENCES Materials.RawMaterialVendor
);