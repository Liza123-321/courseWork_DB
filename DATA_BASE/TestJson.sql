DECLARE @json NVARCHAR(4000)
SET @json = 
N'{
    "info":{  
      "type":1,

      "address":{  
        "town":"Bristol",
        "county":"Avon",
        "country":"England"
      },
      "tags":["Sport", "Water polo"]
   },
   "type":"Basic"
}'
SELECT
  JSON_VALUE(@json, '$.type') as type,
  JSON_VALUE(@json, '$.info.address.town') as town,
  JSON_QUERY(@json, '$.info.tags') as tags

  SELECT object_id, name
FROM sys.tables
FOR JSON PATH

SELECT Id,GeoJson,
     JSON_VALUE(GeoJson, '$.type') as type,
     JSON_VALUE(GeoJson, '$.info.address.town') as town,
	 JSON_QUERY(GeoJson, '$.info.tags') as tags
FROM TEST1 AS t 
WHERE ISJSON( GeoJson) > 0