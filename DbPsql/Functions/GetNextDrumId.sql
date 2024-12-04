Create or Replace Function Distillation.Get_Next_Drum_Id(materialNumber int)
RETURNS VARCHAR(6)
LANGUAGE plpgsql
AS
$$
    Declare 
        id int;
        code varchar(3);
        lot_number varchar(10);

BEGIN
    lot_number = (Select Product_Lot_Number
                From Distillation.Raw_Material_Log Where material_Number = materialNumber 
                Order By Product_Lot_Number Desc Limit 1);
    
    IF(lot_number is null) THEN
    --36178 -> no drums issued 
    --32716 -> drums issued
        return (Select Concat(sequence_id,Material_Code) From Materials.Raw_Material_Vendor Where material_Number = materialNumber); 

    ELSE  
        if(length(lot_number) = 5 or length(lot_number) = 9) THEN
            id = SUBSTRING(lot_number,1,3);
            code = SUBSTRING(lot_number,4,2);
            return CONCAT(id+1,code);
            end if;
        if(length(lot_number) = 6 or length(lot_number) = 10) THEN
            id = SUBSTRING(lot_number,1,4);
            code = SUBSTRING(lot_number,5,2);
            return CONCAT(id+1,code);
            end if;
    END IF;
END;
$$;