<!--
*Author：COCO
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *业务请在@/extension/custom/custom/Base_Language.js此处编写
 -->
<template>
    <view-grid ref="grid"
               :columns="columns"
               :detail="detail"
               :editFormFields="editFormFields"
               :editFormOptions="editFormOptions"
               :searchFormFields="searchFormFields"
               :searchFormOptions="searchFormOptions"
               :table="table"
               :extend="extend">
    </view-grid>
</template>
<script>
    import extend from "@/extension/custom/custom/Base_Language.js";
    import { ref, defineComponent } from "vue";
    export default defineComponent({
        setup() {
            const table = ref({
                key: 'Language_Id',
                footer: "Foots",
                cnName: '多语言',
                name: 'custom/Base_Language',
                url: "/Base_Language/",
                sortName: "Language_Id"
            });
            const editFormFields = ref({"Chinese":"","English":""});
            const editFormOptions = ref([[{"title":"中文","required":true,"field":"Chinese","type":"text"}],
                              [{"title":"英文","required":true,"field":"English","type":"text"}]]);
            const searchFormFields = ref({"Chinese":"","English":""});
            const searchFormOptions = ref([[{"title":"中文","field":"Chinese","type":"like"},{"title":"英文","field":"English","type":"like"}]]);
            const columns = ref([{field:'Language_Id',title:'多语言主键ID',type:'int',width:110,hidden:true,readonly:true,require:true,align:'left'},
                       {field:'Chinese',title:'中文',type:'string',link:true,width:220,require:true,align:'left',sort:true},
                       {field:'English',title:'英文',type:'string',width:220,require:true,align:'left'},
                       {field:'CreateDate',title:'创建时间',type:'datetime',width:110,align:'left',sort:true},
                       {field:'CreateID',title:'创建人编号',type:'int',width:80,hidden:true,align:'left'},
                       {field:'Creator',title:'创建人',type:'string',width:130,align:'left'},
                       {field:'Modifier',title:'修改人',type:'string',width:130,align:'left'},
                       {field:'ModifyDate',title:'修改时间',type:'datetime',width:110,align:'left',sort:true},
                       {field:'ModifyID',title:'修改人编号',type:'int',width:80,hidden:true,align:'left'}]);
            const detail = ref({
                cnName: "#detailCnName",
                table: "#detailTable",
                columns: [],
                sortName: "",
                key: ""
            });
            return {
                table,
                extend,
                editFormFields,
                editFormOptions,
                searchFormFields,
                searchFormOptions,
                columns,
                detail,
            };
        },
    });
</script>
