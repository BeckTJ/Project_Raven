\copy Materials.High_Purity_Material from 'MaterialData.csv' delimiter ',' csv header;

create temporary table vendor(
    MaterialNumber INT NOT NULL PRIMARY KEY,
    VendorName VARCHAR(25) NOT NULL,
    MaterialCode VARCHAR(3) NOT NULL,
    BatchManaged BOOLEAN,
    ContainerNumberRequired BOOLEAN,
    SequenceId INT NOT NULL,
    TotalRecords INT NOT NULL,
    UnitOfIssue VARCHAR(3),
    ParentMaterialNumber INT NOT NULL
);

\copy vendor from 'MaterialVendor.csv' delimiter ',' csv header;

INSERT INTO Materials.Raw_Material_Vendor
(Material_Number,Vendor_Name,Material_Code,Batch_Managed,Container_Number_Required,Sequence_Id,Total_Records,Unit_Of_Issue,Parent_Material_Number)
SELECT MaterialNumber, VendorName, MaterialCode, BatchManaged, ContainerNumberRequired, SequenceId, TotalRecords, UnitOfIssue,
(SELECT Material_Number From Materials.High_Purity_Material WHERE Material_Number = ParentMaterialNumber) from vendor;

\copy Distillation.Raw_Material_Log from 'RawMaterial.csv' delimiter ',' csv header;

INSERT INTO Distillation.Date_Code(Date_Id, Date_Code)
VALUES(1, 'A'),
    (2, 'B'),
    (3, 'C'),
    (4, 'D'),
    (5, 'E'),
    (6, 'F'),
    (7, 'G'),
    (8, 'H'),
    (9, 'I'),
    (10, 'J'),
    (11, 'K'),
    (12, 'L')
