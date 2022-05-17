#openapi4net
- 项目环境：
- VS2019
- OpenAPI4Net SDK 为用友官方发布的 SDK，以最新更新为主。

### 准备工作
- step 1. U8开放平台官网注册
  Link: http://open.yonyouup.com/login/toLogin
- step 2. 申请应用帐号
- step 3. 下载 openapi4net-master，我选的C#, 接口是VS2010开发的
- step4. 申请测试帐号
- step5. 开放平台客户端下载
  Link:https://u8open.yonyou.com/download/client
- step6. 客户端参数和数据库设置

### 关于我们
- [源码下载](https://github.com/85406377/U8DEMO)
- QQ：85406377
- 微信公众号<br/>
  ![微信公众号](http://www.pcyuepu.top/statics/elements/qrcode.png "微信公众号")


### 项目说明
- OpenAPI4Net 主项目
- OpenAPI4Net.Examples 测试项目
- WebApplication1 Web项目
- Visual Studio 2019 版本下编写
- 源码基于 Framework 2.0 编写

### 准备工作
- 使用 SDK 前请先配置：<br/>
  OpenAPI4Net/config/globals.xml

### U8 API 调用过程
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
- 使用测试项目 OpenAPI4Net.WebApplication1，请先配置：<br/>
　　OpenAPI4Net\WebApplication1\Config\globals.xml；
