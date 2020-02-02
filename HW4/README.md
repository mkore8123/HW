HW4：請建立一個解決服務方案(.sln)，內部包含一個 .csproj 並實作Swashbuckle 整合 ASP.NET Core 開發
RESTful Api ，並建立 README.md 說明 Restful Api 的組成元素與特色或限制

RESTful API 由 HTTP Method 動詞 + URI(prefix + API endpoint) 以及 Content-Types 組成，但在類似的實作中，如 .NET Web API 還是會有些差異。

RESTful 採用簡單且統一的Api接口，由於在操作資料時都必須透過 HTTP 所規範的 Method，另外介面中的 URL 只會有單純的代表資料的 endpoint，不會有像是 https://api_name/data/get_all 這種 URL (.NET Web API 即採用這種方式)，讓不同的 Client 能夠更方便的與 Server Api 對接，並且每一種 URI 接口就代表一種資料，降低了系統資料之間的耦合性，讓後端 API 開發上好維護且彈性許多。

但低耦合就代表著高鬆散，當前端 Web的顯示邏輯過於複雜時，例如一個頁面(表徵)需要多種資料時，就必須多發幾個 request 向後端要資料，例如一個部落格頁面除了要文章內容還要作者資料時，就必須一次發兩個request，一旦顯示羅即層複雜起來，就會大大影響系統的效能。