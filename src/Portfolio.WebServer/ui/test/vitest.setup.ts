import "@testing-library/jest-dom/vitest";
import { defineConfig } from "vitest/config";
// import { server } from "./http.mock";

defineConfig({
  test: {
    coverage: {
      reporter: ["text", "json", "html"],
      reportsDirectory: "./coverage",
      include: ["src/**/*.{ts,tsx}"],
      exclude: [
        "**/node_modules/**",
        "**/dist/**",
        "**/*.styles.ts",
        "**/*.test.ts",
        "**/*.test.tsx",
        "**/coverage/**",
      ],
    },
  },
});

// beforeAll(() => {
//   server.listen();
// });

// beforeEach(() => {
//   server.resetHandlers();
// });

// afterAll(() => {
//   server.close();
// });
