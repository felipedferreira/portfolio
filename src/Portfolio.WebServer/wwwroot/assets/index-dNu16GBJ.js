(function(){const c=document.createElement("link").relList;if(c&&c.supports&&c.supports("modulepreload"))return;for(const e of document.querySelectorAll('link[rel="modulepreload"]'))s(e);new MutationObserver(e=>{for(const t of e)if(t.type==="childList")for(const n of t.addedNodes)n.tagName==="LINK"&&n.rel==="modulepreload"&&s(n)}).observe(document,{childList:!0,subtree:!0});function r(e){const t={};return e.integrity&&(t.integrity=e.integrity),e.referrerPolicy&&(t.referrerPolicy=e.referrerPolicy),e.crossOrigin==="use-credentials"?t.credentials="include":e.crossOrigin==="anonymous"?t.credentials="omit":t.credentials="same-origin",t}function s(e){if(e.ep)return;e.ep=!0;const t=r(e);fetch(e.href,t)}})();function i(){return""}class l{async getWeatherforecastAsync(){const c=i();return fetch(c+"/api/weatherforecast").then(r=>{if(console.log(r.status),r.ok)return r.json();throw new Error("Failed to fetch data")}).catch(r=>{throw console.log(r),r})}}const a=new l;function f(){debugger;a.getWeatherforecastAsync().then(o=>console.table(o)).catch(o=>console.error(o))}f();
