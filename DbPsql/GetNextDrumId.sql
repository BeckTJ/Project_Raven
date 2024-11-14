Create Function Get_Next_Drum_Id(materialNumber int)
RETURNS VARCHAR(6)
AS
Declare 
    lotNumber varchar(10)
    id int
BEGIN
    lotNumber = Select Product_Lot_Number From Distillation.Raw_Material_Log Where material_Number = 32716 Order By Product_Lot_Number Desc Limit 1;
    
    If(lotNumber is null)
        Select Concat(sequence_id,Material_Code) From Materials.Raw_Material_Vendor Where material_Number = 32716; --36178 -> no drums issued

    ELSE  
        if(lotNumber) 