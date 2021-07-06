## ViewConfig 介绍

在本文中，我们在.NET Core 程序中使用了 `ViewConfig` 组件来调试配置。


## 安装

通过Nuget搜索 `ViewConfig`，然后在程序中安装，这是一个.net standard 2.0 的组件。 

![](https://blog-1259586045.cos.ap-shanghai.myqcloud.com/clipboard_20210330_054359.png)

## 设置

安装完成以后，需要修改 Startup.cs 文件的 Configure 方法，我们加一行代码 `UseViewConfig`

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{ 
	if (env.IsDevelopment())
	{
		app.UseViewConfig();

		app.UseDeveloperExceptionPage();
		app.UseSwagger(); 

		// ...

} 
```

这里建议在开发环境中使用，和Swagger一样， 然后我们启动程序，然后访问 `/viewconfig` 端点 

![](https://blog-1259586045.cos.ap-shanghai.myqcloud.com/clipboard_20210330_062154.png)

上面列出了程序中所有的配置项，我们可以看到 Key，Value，也可以通过 Provider 知道配置来自与 appsetting.json 文件或者其他，可以通过下拉列表查看不同的 Provider 的配置信息。

## 自定义

默认使用的是 `/viewconfig` 端点，输出的是页面，当然也支持输出 json 和文本，像下面这样

```csharp
// 自定义端点
app.UseViewConfig(x => x.Map("/Info")); 

// 页面格式
app.UseViewConfig(x => x.RenderPage()); 

// Json格式
app.UseViewConfig(x => x.Map().RenderJson()); 

// 文本格式
app.UseViewConfig(x => x.Map("/Info").RenderText());   
```

## 总结

ViewConfig 是一个非常简单的组件，可以帮助我们在.NET Core 程序中调试配置信息，接下来还会支持在.Net Core 控制台项目中使用，需要注意的是，我建议大家只在开发环境中使用它，希望可以对您有帮助。

