import { createApp } from 'vue'
import App from './App.vue'
import  './index.css'
import router from './router.js';
import CodeEditor from 'simple-code-editor';
import GoogleSignInPlugin from "vue3-google-signin"

const app = createApp(App)
app.use(router)

app.component({'code-editor': CodeEditor});

app.use(GoogleSignInPlugin, {
    clientId: '899432219864-5mvlmg84d7sap626jaqc8ojsp8h30ilr.apps.googleusercontent.com',
  });

app.mount('#app')