CREATE USER RavenAdmin;

CREATE DATABASE Raven;

GRANT ALL PRIVILEGES ON DATABASE Raven TO RavenAdmin;

\c raven

CREATE SCHEMA Materials;
CREATE SCHEMA Distillation;
CREATE SCHEMA Quality_Control;

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
    Vendor_Lot_Number VARCHAR(25),
    Sample_Id INT,
    Inspection_Lot_Number BIGINT,
    Container_Number VARCHAR(7),
    Issue_Date TIMESTAMP,
    Net_Weight INT DEFAULT 180,
    Material_Number INT NOT NULL REFERENCES Materials.Raw_Material_Vendor(Material_Number)
);
CREATE TABLE Distillation.Date_Code
(
    Date_Id Int PRIMARY KEY,
    Date_Code CHAR
);
CREATE TABLE Quality_Control.Sample_Status
(
    Sample_Id INT PRIMARY KEY,
    Sample_Type CHAR(3),
    Product_Lot_Number VARCHAR(10),
    Vendor_Lot_Number VARCHAR(25),
    Submit_Date TIMESTAMP,
    Approved BOOLEAN,
    Rejected BOOLEAN,
    Status_Date TIMESTAMP
);
CREATE TABLE Quality_Control.Sample_Required
(
    Required_Id SERIAL NOT NULL PRIMARY KEY,
    Material_Type VARCHAR(25),
    Product_Type VARCHAR(25), -- Old/New, Reclaim, Finished Product
    Assay BOOLEAN,
    Water BOOLEAN,
    Metals BOOLEAN,
    Chloride BOOLEAN,
    Boron BOOLEAN,
    Phosphorus BOOLEAN,
    Material_Number INT REFERENCES Materials.High_Purity_Material(Material_Number)
);
CREATE TABLE Quality_Control.Hazard_Labels
(
    Hazard_Id SERIAL NOT NULL PRIMARY KEY,
    Carcinogen BOOLEAN,
    Flammable BOOLEAN,
    Corrosive BOOLEAN,
    Pyrophoric BOOLEAN,
    Combustable BOOLEAN,
    Sensitizer BOOLEAN,
    Hygroscopic BOOLEAN,
    Irritant BOOLEAN,
    Highly_Toxic BOOLEAN,
    Volitile BOOLEAN,
    Explosive BOOLEAN,
    Peroxidizable BOOLEAN,
    Shelf_Life BOOLEAN,
    Dusty BOOLEAN,
    Material_Number INT REFERENCES Materials.High_Purity_Material(Material_Number)
);
\i ../raven/DataUpload.sql;