local core = require "core"
local utils = require('pos-logic.utils')

local M = core.new_plugin("POS System", "v1.0")

-- Table to store plugin state
M.config = {
    enabled = true,
    prefix = "[POS-SYSTEM]"
}

function M.process_sale(self, productId, quantity)
    local product = Host:GetProduct(productId)

    if product and M.config.enabled then
        local subtotal = product.Price * quantity
        local total = utils.calculate_vat(subtotal) + subtotal

        Host:LogInfo(M.config.prefix .. " Processing: " .. product.Name)
        Host:LogInfo("Total with VAT: " .. total)


        -- You can call C# back to persist data
        Host:SaveTransaction(productId, total)
    end
end

return M -- Return the module table