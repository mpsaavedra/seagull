local M = {}

-- default function for all plugins
M.base_functions = {
    log = function(self, msg)
        Host:LogInfo("[" .. (self.name or "Unknown") .. "]: " .. msg)
    end,
    get_version = function(self)
        return self.version
    end
}

-- instanciate a new plugins with herency
function M.new_plugin(name, version)
    local instance = { name = name, version = version, config = {} }

    -- Metatabla: if does not found somethin on  'instance', search it on 'base_functions'
    setmetatable(instance, { __index = M.base_functions })

    return instance
end

return M