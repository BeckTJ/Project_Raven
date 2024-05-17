CREATE USER RavenAdmin;

CREATE DATABASE Raven;

GRANT ALL PRIVILEGES ON DATABASE Raven TO RavenAdmin;

\c raven

CREATE SCHEMA Materials;
CREATE SCHEMA Distillation;

CREATE TABLE Materials.HighPurityMaterial
(
    MaterialNumber INT NOT NULL PRIMARY KEY,
    MaterialName VARCHAR(25) NOT NULL,
    Binomial VARCHAR(6) NOT NULL,
    PermitNumber VARCHAR(25),
    MaterialCode VARCHAR(3) NOT NULL,
    BatchManaged BIT,
    SequenceId INT NOT NULL,
    TotalRecords INT NOT NULL,
    UnitOfIssue VARCHAR(3)
);
CREATE TABLE Materials.RawMaterialVendor 
(
    MaterialNumber INT NOT NULL PRIMARY KEY,
    VendorName VARCHAR(25) NOT NULL,
    MaterialCode VARCHAR(3) NOT NULL,
    BatchManaged BIT,
    ContainerNumberRequired BIT,
    SequenceId INT NOT NULL,
    TotalRecords INT NOT NULL,
    UnitOfIssue VARCHAR(3),
    ParentMaterialNumber INT NOT NULL REFERENCES Materials.HighPurityMaterial(MaterialNumber)
);
CREATE TABLE Distillation.RawMaterialLog
(
    ProductLotNumber VARCHAR(10) NOT NULL PRIMARY KEY,
    ProductBatchNumber INT,
    VendorName VARCHAR(25) NOT NULL,
    VendorLotNumber VARCHAR(25),
    SampleId INT,
    InspectionLotNumber INT,
    ContainerNumber VARCHAR(7),
    IssueDate DATE NOT NULL,
    NetWeight INT DEFAULT 180,
    MaterialNumber INT NOT NULL REFERENCES Materials.RawMaterialVendor(MaterialNumber)
)
\i ../raven/DataUpload.sql;