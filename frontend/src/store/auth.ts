// stores/auth.js
import { defineStore } from 'pinia'
const apiUrl = import.meta.env.VITE_API_URL;

export const useAuthStore = defineStore('auth', {

  state: () => ({
    user: '',
    token: '',
    loading: false,
    error: '',
  }),

  actions: {

    async register(username: string, password: string) {
      const response = await fetch(apiUrl + '/api/auth/register', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          username: username,
          password: password
        })
      });

      if (response.status == 200) {
        return true;
      } else {
        return false;
      }
    },

    async login(username: string, password: string) {

      this.loading = true;
      this.error = '';

      try {
        const response = await fetch(apiUrl + '/api/auth/login', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify({
            username,
            password
          })
        });

        if (response.status == 200) {
          const data = await response.json();
          this.token = data.accessToken;
          this.user = data.userRespone;

          localStorage.setItem('token', this.token || '');
          localStorage.setItem('user', JSON.stringify(this.user));
        } else {
          alert("Invalid username or password");
        }

      } catch (err) {
        this.error = 'Login failed';


      } finally {
        this.loading = false;
      }

    },

    logout() {
      this.token = '';
      this.user = '';
      localStorage.removeItem('token');
      localStorage.removeItem('user');
    },

    loadStoredAuth() {
      const token = localStorage.getItem('token');
      const user = localStorage.getItem('user');
      if (token && user) {
        this.token = token;
        this.user = JSON.parse(user);
      }
    }
  },
})
