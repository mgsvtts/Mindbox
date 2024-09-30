select 
    p.name as product_name,
    c.name as category_name
from 
    products p
left join 
    product_categories pc on p.id = pc.product_id
left join 
    categories c on pc.category_id = c.id
order by 
    p.name, c.name;