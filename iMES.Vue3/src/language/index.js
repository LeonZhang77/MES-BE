import { createI18n } from "vue-i18n";
import zhCN from "./locales/zh-CN";
import enUS from "./locales/en-US";
import http from "@/../src/api/http.js";

let language = localStorage.getItem("language") || navigator.language; //  获取本地存储 || 根据浏览器语言设置
var zh = {};
var en = {};
http.post('/api/Base_Language/getPageData', {}, true).then((result) => {
    console.log("6666",result)
              result.rows.forEach(lan => {
                  var chineseArr = lan.Chinese;
                  var englishArr = lan.English;
                  zh[chineseArr]=chineseArr;
                  en[chineseArr]=englishArr;
              });

          });

const i18n = createI18n({
  legacy: false, // 使用Composition API，这里必须设置为false
  locale: language, // 默认显示语言
  globalInjection: true, // 全局注册$t方法
  messages: {
    // "zh-CN": zhCN,
    // "en-US": enUS,
    "zh-CN": zh,
    "en-US": en,
  },
});

export default i18n;
