Create Function Get_Next_Drum_Id(materialNumber int)
RETURNS VARCHAR(6)
AS
Declare 
    lotNumber varchar(10)
    id int
    code varchar(3)
BEGIN
    lotNumber = Select Product_Lot_Number From Distillation.Raw_Material_Log Where material_Number = 32716 Order By Product_Lot_Number Desc Limit 1;
    
    If(lotNumber is null)
        return Select Concat(sequence_id,Material_Code) From Materials.Raw_Material_Vendor Where material_Number = 32716; --36178 -> no drums issued

    ELSE  
        if(length(lotNumber) == 5 || length(lotNumber) == 9)
            id = SUBSTRING(lotNumber,1,3);
            code = SUBSTRING(lotNumber,4,2);
            return CONCAT(id+1,code);
        if(length(lotNumber)== 6 || length(lotNumber) == 10)
            id = SUBSTRING(lotNumber,1,4);
            code = SUBSTRING(lotNumber,5,2);
            return CONCAT(id+1,code);
END