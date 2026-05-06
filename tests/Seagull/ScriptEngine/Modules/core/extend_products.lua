-- define a base product behaviour
local ProductMethods = {}
function ProductMethods:get_taxed_price()
    return self.Price * 1.21
end

-- intercept object creation to add some othe methods
local original_get_product = Host.GetProduct
Host.GetProduct = function(self, id)
    local p = original_get_product(self, id)
    if p and p._type == "Product" then
        setmetatable(p, { __index = ProductMethods })
    end
    return p
end

-- local p = Host:GetProduct(1)
-- -- now the object has a methods'get_taxed_price' that does not exists on C#
-- print(p.Name .. " cuesta: " .. p:get_taxed_price())