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

select raw_material_log.material_number, vendor_name, product_lot_number, vendor_lot_number, batch_number, container_number, net_weight, issue_date, sample_id
    -- sample_type, sample_status.sample_id, inspection_lot_number, status_date, approved, rejected
from distillation.raw_material_log
join materials.raw_material_vendor on raw_material_vendor.material_number = raw_material_log.material_number
join materials.material_vendor_lots on material_vendor_lots.lot_id = raw_material_log.lot_id
-- join quality_control.sample_status on sample_status.sample_id = raw_material_log.sample_id

select * from materials.raw_material_vendor 
join distillation.raw_material_log on raw_material_log.material_number = Raw_Material_Vendor.material_number
where raw_material_vendor.material_number = 32716

