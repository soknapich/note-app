<template>
  <div class="min-h-screen">
   Username: {{ auth.user.username }}, Role: {{ auth.user.role }}
  </div>
</template>

<script lang="ts">
import { useAuthStore } from '@/store/auth';
export default {
  name: "Home",
  setup() {
    const auth = useAuthStore()
    //console.log(auth);

    return {
      auth
    }
  }
}
</script>