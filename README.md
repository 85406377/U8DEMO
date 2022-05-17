#openapi4net

- OpenAPI4Net SDK 为用友官方发布的 SDK，以最新更新为主。

### 版权
- 用友优普技术有限公司
- 用友优普开放平台

### 关于我们
- [用友优普开放平台官网](http://open.yonyouup.com)
- QQ 交流群：320582917
- 微信公众号<br/>
  ![微信公众号](http://open.yonyouup.com/styles/function/documentCenter/images/qaCode.png "微信公众号")


### 项目说明
- OpenAPI4Net 主项目
- OpenAPI4Net.Examples 测试项目
- Visual Studio 2010 版本下编写
- 源码基于 Framework 2.0 编写

### 准备工作
- 使用 SDK 前请先配置：<br/>
  OpenAPI4Net/config/globals.xml

### API 调用过程
1. 实例化 API 类<br/>
   SaleorderApi api = new SaleorderApi();<br/> // 销售订单 API
2. 调用 API 方法<br/>
   BusinessObject bo = api.Get(id); // 单个资源查询<br/>
   bo = api.BatchGet(IDictionary<string, string> params); // 批量查询<br/>
   ...
3. 返回结果取值方式<br/>
   _bo.BodyObject_ // 返回单行请参考，类型为 ApiDictionary<br/>
   _bo.BodyArray_ // 返回多行请参考,类型为 ApiList<br/>
   _bo.Body_ // 返回单行或多行<br/>
   _bo.Full_ // 包含 errcode, errmsg 等在内的完整信息<br/>
   <br/>
   _ApiDictionary.IsArray_ // 判断某个节点位置下的某个属性是否为数组<br/>

4） 返回结果取值示例<br/>
   请参考 OpenAPI4Net.Examples 代码。<br/>

### 依赖
- Newtonsoft.Json.dll

### 部署
- 请在应用程序文件夹下放置 config/globals.xml；<br/>
　　app.exe<br/>
　　　　|- config<br/>
　　　　　　|- globals.xml<br/>
- 使用测试项目 OpenAPI4Net.Examples，请先配置：<br/>
　　OpenAPI4Net.Examples\bin\Debug\Config\globals.xml；