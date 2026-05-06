local M = {}

function M.apply_tax(price)
    return price * 1.15 -- 15% tax
end

function M.check_enough_on_stock()
    return true
end

return M