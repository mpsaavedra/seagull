-- import core module
local core = require("core")
local M = core.new_plugin("Inventory Manager", "v1.0")

-- Import internal modules
local utils = require('inventory-manager.utils')
local logic = require('inventory-manager.data_logic')

-- Local plugin state

-- This function will be called from C# or other scripts
function OnInventoryCheck(productId)
    Host:LogInfo("Plugin '" .. M.name .. "' triggered.")

    local product = Host:GetProduct(productId)

    if product then
        local final_price = logic.apply_tax(product.Price)
        local display_price = utils.format_currency(final_price)
        local on_stock = logic.check_enough_on_stock()

        Host:LogInfo("Product: " ..
            product.Name .. " | Price with Tax: " .. display_price .. " Enough on stock " .. on_stock)
    end
end

print("Plugin 'inventory-manager' loaded successfully!")