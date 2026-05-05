-- Logic to apply a seasonal discount via EFCore
function OnProcessInventory()
    local productId = 101
    local product = App:GetRepository()

    if product ~= nil then
        -- Accessing C# properties directly
        local currentPrice = product.Price
        
        if currentPrice > 100 then
            local discountPrice = currentPrice * 0.90 -- 10% discount
            App:UpdatePrice(productId, discountPrice)
            print("Discount applied to: " .. product.Name)
        end
    else
        print("Product not found.")
    end
end