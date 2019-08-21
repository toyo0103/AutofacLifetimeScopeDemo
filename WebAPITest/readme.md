1. 執行起來後呼叫 `api/test` ,觀察 ValidateTokenHandler 與 ApiController 交互的結果

2. 藉由調整 AutofacConfig 裡面的以下兩行註解觀看結果
```csharp
  //builder.RegisterType<MockDBContext>().SingleInstance();
    builder.RegisterType<MockDBContext>().InstancePerLifetimeScope();
```




