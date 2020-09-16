
CREATE VIEW [UM].[ViewGroupPropertyValues]
AS
SELECT        UM.Properties.Id AS PropertyId, UM.Properties.Name, UM.Properties.DefaultValue, UM.Properties.DataType, UM.GroupPropertyValues.GroupId, 
                         UM.GroupPropertyValues.Value
FROM            UM.Properties LEFT OUTER JOIN
                         UM.GroupPropertyValues ON UM.Properties.Id = UM.GroupPropertyValues.PropertyId
WHERE        (UM.Properties.Type = 3)