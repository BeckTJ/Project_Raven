select * from Materials.High_Purity_Material;
select * from Materials.Raw_Material_Vendor;
select * from Materials.Material_Vendor_Lots;
select * from Distillation.Raw_Material_Log;
select * from Distillation.Date_Code;
select * from Quality_Control.Sample_Required;
select * from Quality_Control.Sample_Status;

select Distillation.get_next_drum_id(36178);    --36178 -> no drums issued 
select Distillation.get_next_drum_id(32716);    --32716 -> drums issued 
select Distillation.get_next_drum_id(3665760);   --3665760 -> product lot number is 6 or 10

update distillation.raw_material_log
Set lot_id = 5
where Product_Lot_Number = '801DA'