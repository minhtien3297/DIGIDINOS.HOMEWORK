export default {
  // Disable server-side rendering: https://go.nuxtjs.dev/ssr-mode
  ssr: false,

  // Global page headers: https://go.nuxtjs.dev/config-head
  head: {
    title: "Report",
    htmlAttrs: {
      lang: "en"
    },
    meta: [
      { charset: "utf-8" },
      { name: "viewport", content: "width=device-width, initial-scale=1" },
      { hid: "description", name: "description", content: "" }
    ],
    link: [
      { rel: "icon", type: "image/x-icon", href: "/favicon.ico" },
      {
        rel: "stylesheet",
        type: "text/css",
        href:
          "https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"
      }
    ],
    script: [
      {
        src:
          "https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"
      },
      { src: "https://code.jquery.com/jquery-3.3.1.slim.min.js" },
      {
        src:
          "https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"
      }
    ]
  },

  // Global CSS: https://go.nuxtjs.dev/config-css
  css: [],

  // Plugins to run before rendering page: https://go.nuxtjs.dev/config-plugins
  plugins: [],

  // Auto import components: https://go.nuxtjs.dev/config-components
  components: true,

  // Modules for dev and build (recommended): https://go.nuxtjs.dev/config-modules
  buildModules: [],

  // Modules: https://go.nuxtjs.dev/config-modules
  modules: [
    // https://go.nuxtjs.dev/bootstrap
    "bootstrap-vue/nuxt",
    //auth nuxtjs
    "@nuxtjs/axios",
    "@nuxtjs/auth-next"
  ],

  // Build Configuration: https://go.nuxtjs.dev/config-build
  build: {},

  //set base url
  axios: {
    baseURL: "https://localhost:44343/api/"
  },

  //set up auth
  auth: {
    redirect: {
      callback: "/login"
    },
    strategies: {
      local: {
        token: {
          property: "access_token",
          required: true,
          type: "Bearer"
        },
        user: {
          property: "user"
          // autoFetch: true
        },
        endpoints: {
          login: {
            url: "/login",
            method: "post",
            propertyName: "access_token"
          },
          logout: false,
          user: {
            url: "/user",
            method: "get",
            propertyName: "data"
          }
        }
      }
    }
  }
};
