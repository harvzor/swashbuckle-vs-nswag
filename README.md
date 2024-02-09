## Comparison

|                                   | Swashbuckle                                                                           | NSwag                                                                                 | Thoughts                                                                                                                                               |
|-----------------------------------|---------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------|
| GitHub                            | https://github.com/domaindrivendev/Swashbuckle.AspNetCore                             | https://github.com/RicoSuter/NSwag                                                    |                                                                                                                                                        |
| GitHub Stars                      | 5k                                                                                    | 6.3k                                                                                  | Comparing stars is not fair as NSwag has more functionality than Swashbuckle, so perhaps people are starring different specific things.                |
| NuGet                             | https://www.nuget.org/packages/swashbuckle.aspnetcore/                                | https://www.nuget.org/packages/NSwag.AspNetCore/                                      |                                                                                                                                                        |
| NuGet downloads (per day average) | 172.1k                                                                                | 18.1k                                                                                 | Swashbuckle has 9x more downloads.                                                                                                                     |
| Swagger UI version shipped        | v4.15.5, Wed, 09 Nov 2022 06:53:00                                                    | v5.7.2, Mon, 18 Sep 2023 07:42:57                                                     | Used `JSON.stringify(versions)` in console to find the version. Swagger UI could be swapped out for a more recent version regardless of the generator. |
| OpenApi version                   | [v3.0.1, Dec 7 2017](https://github.com/OAI/OpenAPI-Specification/releases/tag/3.0.1) | [3.0.0, Jul 26 2017](https://github.com/OAI/OpenAPI-Specification/releases/tag/3.0.0) | [Latest is v3.1.0, Feb 16 2021](https://spec.openapis.org/oas/latest.html).                                                                            |
| GitHub commits (2023)             | 1                                                                                     | ~97                                                                                   |                                                                                                                                                        |
| Owners                            | domaindrivendev                                                                       | RicoSuter                                                                             | Doesn't seem like either repo allows any other users to have admin rights.                                                                             |
| Sponsorship                       | No sponsorship is labeled.                                                            | Sponsors are clearly labeled.                                                         | NSwag clearly has sponsorship which gives the creator incentive to continue to support it.                                                             |

Stats true as of 12/01/2024.

### Feature comparison

| Feature               | Swashbuckle | NSwag |
|-----------------------|-------------|-------|
| Supports Minimal APIs | ✔           | ✔     |

### Default JSON

Swashbuckle:

```json
{
  "openapi": "3.0.1",
  "info": {
    "title": "SwashbuckleVsNSwag.Swashbuckle",
    "version": "1.0"
  },
  "paths": {
    "/WeatherForecast": {
      "get": {
        "tags": [
          "WeatherForecast"
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/WeatherForecastDto"
                  }
                }
              },
              "application/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/WeatherForecastDto"
                  }
                }
              },
              "text/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/WeatherForecastDto"
                  }
                }
              }
            }
          }
        }
      }
    }
  },
  "components": {
    "schemas": {
      "WeatherForecastDto": {
        "type": "object",
        "properties": {
          "date": {
            "type": "string",
            "format": "date-time"
          },
          "temperatureC": {
            "type": "integer",
            "format": "int32"
          },
          "temperatureF": {
            "type": "integer",
            "format": "int32",
            "readOnly": true
          },
          "summary": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      }
    }
  }
}
```

NSwag:

```json
{
  "x-generator": "NSwag v14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))",
  "openapi": "3.0.0",
  "info": {
    "title": "My Title",
    "version": "1.0.0"
  },
  "servers": [
    {
      "url": "http://localhost:5047"
    }
  ],
  "paths": {
    "/WeatherForecast": {
      "get": {
        "tags": [
          "WeatherForecast"
        ],
        "operationId": "WeatherForecast_Get",
        "responses": {
          "200": {
            "description": "",
            "content": {
              "application/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/WeatherForecastDto"
                  }
                }
              }
            }
          }
        }
      }
    }
  },
  "components": {
    "schemas": {
      "WeatherForecastDto": {
        "type": "object",
        "additionalProperties": false,
        "properties": {
          "date": {
            "type": "string",
            "format": "date-time"
          },
          "temperatureC": {
            "type": "integer",
            "format": "int32"
          },
          "temperatureF": {
            "type": "integer",
            "format": "int32"
          },
          "summary": {
            "type": "string",
            "nullable": true
          }
        }
      }
    }
  }
}
```

## Remapping types

Swashbuckle:

```csharp
options.MapType<TimeSpan>(() => new OpenApiSchema
{
    Type = "string",
    Example = new OpenApiString("00:00:00")
});
```

NSwag:

```csharp
configure.SchemaSettings.TypeMappers.Add(new PrimitiveTypeMapper(typeof(TimeSpan), schema =>
{
    schema.Format = "string";
    schema.Type = JsonObjectType.String;
    schema.Example = "00:00:00";
}));
```

## Questions

- comprehensive list of features?
- supports open generic types?
