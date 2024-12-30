import { defineProject } from "vitest/config";

export default defineProject({
  test: {
    environment: "happy-dom",
    include: ["src/**/*.test.ts"],
    globals: true,
    setupFiles: "./test/vitest.setup.ts",
  },
});