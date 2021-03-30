## ViewConfig ����

�����ǵĳ����У�������ʱ��Ҫ֪��һ������������һ��Providerִ�еģ��Լ����ó�ͻ�������ǵ�����û����Ч���ڱ����У�������.NET Core ������ʹ���� `ViewConfig` ������������á�


## ��װ

ͨ��Nuget���� `ViewConfig`��Ȼ���ڳ����а�װ������һ��.net standard 2.0 ������� 

![](https://blog-1259586045.cos.ap-shanghai.myqcloud.com/clipboard_20210330_054359.png)

## ����

��װ����Ժ���Ҫ�޸� Startup.cs �ļ��� Configure ���������Ǽ�һ�д��� `UseViewConfig`

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

���ｨ���ڿ���������ʹ�ã���Swaggerһ���� Ȼ��������������Ȼ����� `/viewconfig` �˵� 

![](https://blog-1259586045.cos.ap-shanghai.myqcloud.com/clipboard_20210330_062154.png)

�����г��˳��������е���������ǿ��Կ��� Key��Value��Ҳ����ͨ�� Provider ֪������������ appsetting.json �ļ���������������ͨ�������б�鿴��ͬ�� Provider ��������Ϣ��

## �Զ���

Ĭ��ʹ�õ��� `/viewconfig` �˵㣬�������ҳ�棬��ȻҲ֧����� json ���ı�������������

```csharp
// �Զ���˵�
app.UseViewConfig(x => x.Map("/Info")); 

// ҳ���ʽ
app.UseViewConfig(x => x.RenderPage()); 

// Json��ʽ
app.UseViewConfig(x => x.Map().RenderJson()); 

// �ı���ʽ
app.UseViewConfig(x => x.Map("/Info").RenderText());   
```

## �ܽ�

ViewConfig ��һ���ǳ��򵥵���������԰���������.NET Core �����е���������Ϣ������������֧����.Net Core ����̨��Ŀ��ʹ�ã���Ҫע����ǣ��ҽ�����ֻ�ڿ���������ʹ������ϣ�����Զ����а�����

