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

create temporary table vendorLot(
    LotId INT PRIMARY KEY,
    VendorLotNumber VARCHAR(25),
    BatchNumber INT,
    Quantity Int,
    MaterialNumber INT
);
\copy vendorLot from 'VendorLot.csv' delimiter ',' csv header;

INSERT INTO Materials.Material_Vendor_Lots(Lot_Id,Vendor_Lot_Number,Batch_Number,Quantity,Material_Number)
SELECT LotId,VendorLotNumber,BatchNumber,Quantity,(SELECT Material_Number FROM Materials.Raw_Material_Vendor WHERE Material_Number = MaterialNumber)
FROM vendorLot;


\copy Quality_Control.Sample_Status from 'SampleStatus.csv' delimiter ',' csv header;

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
    (12, 'L');

INSERT INTO Quality_Control.Sample_Required(Material_Type,Product_Type,Assay,Water,Metals,Chloride,Boron,Phosphorus,Material_Number)
VALUES('Finish Product','Finish Product','1','1','1','1','0','0',(SELECT Material_Number FROM Materials.High_Purity_Material WHERE Material_Number = 58245)),
    ('Finish Product','Finish Product','1','0','1','0','1','0',(SELECT Material_Number FROM Materials.High_Purity_Material WHERE Material_Number = 58423)),
    ('Finish Product','Finish Product','1','1','1','0','1','1',(SELECT Material_Number FROM Materials.High_Purity_Material WHERE Material_Number = 58931)),
    ('Finish Product','Finish Product','1','0','1','1','0','0',(SELECT Material_Number FROM Materials.High_Purity_Material WHERE Material_Number = 58765)),
    ('Finish Product','Finish Product','1','0','1','1','1','1',(SELECT Material_Number FROM Materials.High_Purity_Material WHERE Material_Number = 58971)),
    ('Finish Product','Finish Product','1','1','1','1','0','0',(SELECT Material_Number FROM Materials.High_Purity_Material WHERE Material_Number = 58143)),
    ('Raw Material','New','1','1','1','0','0','0',(SELECT Material_Number FROM Materials.High_Purity_Material WHERE Material_Number = 58245)),
    ('Raw Material','Old','1','1','0','0','0','0',(SELECT Material_Number FROM Materials.High_Purity_Material WHERE Material_Number = 58245)),
    ('Raw Material','New','1','1','1','1','1','0',(SELECT Material_Number FROM Materials.High_Purity_Material WHERE Material_Number = 58423)),
    ('Raw Material','New','1','1','1','1','1','1',(SELECT Material_Number FROM Materials.High_Purity_Material WHERE Material_Number = 58931)),
    ('Raw Material','New','0','0','1','1','0','0',(SELECT Material_Number FROM Materials.High_Purity_Material WHERE Material_Number = 58765)),
    ('Raw Material','New','1','0','1','1','1','1',(SELECT Material_Number FROM Materials.High_Purity_Material WHERE Material_Number = 58971)),
    ('Raw Material','Old','1','0','0','0','0','0',(SELECT Material_Number FROM Materials.High_Purity_Material WHERE Material_Number = 58971)),
    ('Raw Material','New','1','1','1','0','0','0',(SELECT Material_Number FROM Materials.High_Purity_Material WHERE Material_Number = 58143)),
    ('Raw Material','Old','1','1','0','0','0','0',(SELECT Material_Number FROM Materials.High_Purity_Material WHERE Material_Number = 58143)),
    ('Reclaim','Reclaim','1','1','0','0','1','0',(SELECT Material_Number FROM Materials.High_Purity_Material WHERE Material_Number = 58423)),
    ('Reclaim','Reclaim','1','1','0','0','0','0',(SELECT Material_Number FROM Materials.High_Purity_Material WHERE Material_Number = 58931)),
    ('Reclaim','Reclaim','0','0','1','0','0','0',(SELECT Material_Number FROM Materials.High_Purity_Material WHERE Material_Number = 58765));

CREATE temporary TABLE Raw_Material
(
    Product_Lot_Number VARCHAR(10) NOT NULL PRIMARY KEY,
    Vendor_Lot_Number VARCHAR(25),
    Batch_Number INT,
    Container_Number VARCHAR(7),
    Issue_Date TIMESTAMP,
    Net_Weight INT ,
    Material_Number INT,
    SampleId INT 
);

    \copy Raw_Material from 'RawMaterial.csv' delimiter ',' csv header;

    INSERT INTO Distillation.Raw_Material_Log(Product_Lot_Number,Container_Number,Issue_Date,Net_Weight,Lot_Id,Material_Number,Sample_Id)
    SELECT Product_Lot_Number,Container_Number,Issue_Date,Net_Weight,
    (SELECT Lot_Id FROM Materials.Material_Vendor_Lots WHERE Vendor_Lot_Number = Raw_Material.Vendor_Lot_Number AND Batch_Number = Raw_Material.Batch_Number),
    (SELECT Material_Number FROM Materials.Raw_Material_Vendor WHERE Material_Number = Raw_Material.Material_Number),
    (SELECT Sample_Id FROM Quality_Control.Sample_Status WHERE Sample_Id = SampleId) FROM Raw_Material;