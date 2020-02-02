HW2：請說明 .NET Core, .NET Standard 與 .NET Framework的差別與優略

.NET Standard：
透過制定一系列.NET API的正式規範提供所有平台的.NET runtime實作，

	1.定義一致的 BCL(Base Class Library) API 集合，是一份協議、一系列API介面(Interface)，但並不直接實作。
	2.可讓開發人員使用這組相同的 API，產生可跨 .NET 實作使用的可攜式程式庫。
	3.減少或甚至排除因 .NET API 而必須對共用原始檔進行的條件式編譯，僅適用於 OS API。

.NET Framework：
	1.傳統的 .NET 開發框架，行之有年且支援的技術內容最豐富，維護或升級舊有 .NET Framework 相較容易。
	2.以 Windows 為主的系統架構進行開發及佈署，不支援其他系統平台


.NET Core：
	1.有別於 .NET Framework 只能在 Windows 開發建置，.NET Core 達到真正的跨平台(除了Windows，可在 Linux、Mac 開發及佈署)
	2.相較於 .NET Framework 是更加模組化，整體的速度和使用的資源更少。更加符合現今 Microservice 和 Container模式執行的結構。
	3.在 .NET Framework 支援的技術不一定會在 .NET Core 找到

.NET Standard 是 .NET API 的實作規範，符合該實作的有 .NET Framework(傳統僅支援 Windows)、.NET Core(新實作跨平台)，或是其他的 Xamarin、Mono 等
目前確定的是 .NET 4.8 是最後一個 .NET Framework 版本，未來 .NET Core 將會以 .NET 5 版本繼承 .NET 路線繼續發展下去。

