# NewCustmerCheck
## 用于淘宝与支付宝的拉新数据查询和导出网站

---

本网站**基于Asp.net core 2.2 + Mysql8.0**

---

## 图片

![支付宝拉新明细](https://github.com/simplerjiang/NewCustmerCheck/blob/master/NewCustomerCheck/Image/AlipayDetail.png)

![支付宝拉新总数据](https://github.com/simplerjiang/NewCustmerCheck/blob/master/NewCustomerCheck/Image/AlipaySum.png)

![淘宝拉新活动明细](https://github.com/simplerjiang/NewCustmerCheck/blob/master/NewCustomerCheck/Image/TaoBaodetail.png)

#### 使用的接口

**alipay.user.invite.offlinedetail.query**(支付宝线下拉新结算明细数据查询)

**alipay.user.invite.offlinesummary.query**(支付宝线下拉新结算汇总数据查询)

**taobao.tbk.dg.newuser.order.get**（淘宝客新用户订单API--导购）

**taobao.tbk.dg.newuser.order.sum** (拉新活动汇总API--导购)

---

#### 使用方法

1.下载项目，打开Websiteconfig.cs输入用户淘宝与支付宝等信息。

2.打开appsettings.json 修改数据库连接字符串。

3.使用程序包管理控制台进行Update-Database 数据库迁移。

4.发布编译项目，放置目标平台，直接访问网站即可。

**注意** 使用支付宝接口需要联系支付宝官方获取淘宝客API权限才能使用，淘宝接口需著注册阿里妈妈，并创建淘宝客网站权限才可使用

作者QQ：1013171256
