CREATE USER RavenAdmin;

CREATE DATABASE Raven;

GRANT ALL PRIVILEGES ON DATABASE Raven TO RavenAdmin;

\c raven

CREATE SCHEMA Materials;
CREATE SCHEMA Distillation;

CREATE TABLE Materials.High_Purity_Material
(
    Material_Number INT NOT NULL PRIMARY KEY,
    Material_Name VARCHAR(25) NOT NULL,
    Binomial VARCHAR(6) NOT NULL,
    Permit_Number VARCHAR(25),
    Material_Code VARCHAR(3) NOT NULL,
    Batch_Managed BOOLEAN,
    Sequence_Id INT NOT NULL,
    Total_Records INT NOT NULL,
    Unit_Of_Issue VARCHAR(3)
);
CREATE TABLE Materials.Raw_Material_Vendor 
(
    Material_Number INT NOT NULL PRIMARY KEY,
    Vendor_Name VARCHAR(25) NOT NULL,
    Material_Code VARCHAR(3) NOT NULL,
    Batch_Managed BOOLEAN,
    Container_Number_Required BOOLEAN,
    Sequence_Id INT NOT NULL,
    Total_Records INT NOT NULL,
    Unit_Of_Issue VARCHAR(3),
    Parent_Material_Number INT NOT NULL REFERENCES Materials.High_Purity_Material(Material_Number)
);
CREATE TABLE Distillation.Raw_Material_Log
(
    Product_Lot_Number VARCHAR(10) NOT NULL PRIMARY KEY,
    Product_Batch_Number INT,
    Vendor_Name VARCHAR(25) NOT NULL,
    Vendor_Lot_Number VARCHAR(25),
    Sample_Id INT,
    Inspection_Lot_Number BIGINT,
    Container_Number VARCHAR(7),
    Issue_Date DATE,
    Net_Weight INT DEFAULT 180,
    Material_Number INT NOT NULL REFERENCES Materials.Raw_Material_Vendor(Material_Number)
);
CREATE TABLE Distillation.Date_Code
(
    Date_Id Int PRIMARY KEY,
    Date_Code CHAR
);
\i ../raven/DataUpload.sql;