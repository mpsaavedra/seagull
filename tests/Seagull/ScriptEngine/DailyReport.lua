-- File: /Plugins/DailyReport.lua

function Main()
    print("--- Starting Daily Report Plugin ---")
    
    -- Using the EFCore Bridge we built previously
    local inventory = App:GetProduct(502)
    
    if inventory ~= nil then
        App:LogInfo("Checking stock for: " .. inventory.Name)
        
        if inventory.Stock < 10 then
            App:LogInfo("Low stock detected. Sending alert...")
            -- Here you could call App:SendEmailNotification(...)
        end
    end
end