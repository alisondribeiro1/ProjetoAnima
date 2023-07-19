<template>
  <v-hover v-slot="{ isHovering, props }">
    <v-card
      class="pt-6"
      :height="height"
      :width="width"
      :elevation="isHovering ? 16 : 4"
      v-bind="props"
      @Click="handleClick"
    >
      <v-icon size="x-large" class="mt-3" :icon="icon"></v-icon>
      <v-card-title v-if="title !== ''">
        {{ title }}
      </v-card-title>
    </v-card>
  </v-hover>
</template>

<script setup lang="ts">
import { GenericCardModel } from "@/corelib/model/GenericCardModel";

const props = withDefaults(defineProps<GenericCardModel>(), {
  title: "",
  icon: "",
  height: "150px",
  width: "150px",
});

const handleClick = () => {
  if (props.action) {
    props.action?.();
  }
};
</script>
