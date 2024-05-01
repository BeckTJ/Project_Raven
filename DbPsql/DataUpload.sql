copy Materials.HighPurityMaterial from '/usr/raven/MaterialData.csv' delimiter ',' csv header;

--drop table vendor;
    create temporary table vendor(
        MaterialNumber INT NOT NULL PRIMARY KEY,
        VendorName VARCHAR(25) NOT NULL,
        MaterialCode VARCHAR(3) NOT NULL,
        BatchManaged BIT DEFAULT 0::bit,
        ContainerNumberRequired BIT DEFAULT 0::bit,
        SequenceId INT NOT NULL,
        TotalRecords INT NOT NULL,
        UnitOfIssue VARCHAR(3),
        ParentMaterialNumber INT NOT NULL
    );

    copy vendor from '/usr/raven/Data/MaterialVendor.csv' delimiter ',' csv header;
    
    INSERT INTO Materials.RawMaterialVendor
    (MaterialNumber,VendorName,MaterialCode,BatchManaged,ContainerNumberRequired,SequenceId,TotalRecords,UnitOfIssue,ParentMaterialNumber)
    SELECT MaterialNumber, VendorName, MaterialCode, BatchManaged, ContainerNumberRequired, SequenceId, TotalRecords, UnitOfIssue,
    (SELECT MaterialNumber From Materials.HighPurityMaterial WHERE MaterialNumber = ParentMaterialNumber) from vendor;