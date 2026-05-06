local M = {}

function M.format_currency(value)
    return "$" .. string.format("%.2f", value)
end

return M