import App from './App.vue'
import { createApp } from 'vue'
import { registerPlugins } from '@/plugins'
// Vuetify
import 'vuetify/styles';
import * as labs from 'vuetify/labs/components';
import { createVuetify } from 'vuetify';
import * as components from 'vuetify/components';
import * as directives from 'vuetify/directives';

const vuetifyOptions = {
  components: {
    ...labs,
    ...components,
  },
  directives,
};
const vuetify = createVuetify(vuetifyOptions);

const app = createApp(App)

registerPlugins(app)
app.use(vuetify);
app.mount('#app')
