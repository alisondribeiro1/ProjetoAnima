import axios from "axios";

async function sendGPTMessage(message) {
    try {
        const response = await axios.post("https://api.openai.com/v1/chat/completions", {
            "model": "gpt-3.5-turbo",
            "messages": [{"role": "user", "content": message}]
        }, {
            headers: {
                "Authorization": `Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6Ik1UaEVOVUpHTkVNMVFURTRNMEZCTWpkQ05UZzVNRFUxUlRVd1FVSkRNRU13UmtGRVFrRXpSZyJ9.eyJodHRwczovL2FwaS5vcGVuYWkuY29tL3Byb2ZpbGUiOnsiZW1haWwiOiJnZW9yZGFuaW1hY2hhZG83NTZAZ21haWwuY29tIiwiZW1haWxfdmVyaWZpZWQiOnRydWV9LCJodHRwczovL2FwaS5vcGVuYWkuY29tL2F1dGgiOnsidXNlcl9pZCI6InVzZXItSjBUT2FSRXdlVGxIOWxKeW92WGFVdXVDIn0sImlzcyI6Imh0dHBzOi8vYXV0aDAub3BlbmFpLmNvbS8iLCJzdWIiOiJnb29nbGUtb2F1dGgyfDExMTc0NDc5MDYxNjAxMTY5NzgxMyIsImF1ZCI6WyJodHRwczovL2FwaS5vcGVuYWkuY29tL3YxIiwiaHR0cHM6Ly9vcGVuYWkub3BlbmFpLmF1dGgwYXBwLmNvbS91c2VyaW5mbyJdLCJpYXQiOjE2ODE1MTg1NjIsImV4cCI6MTY4MjcyODE2MiwiYXpwIjoiVGRKSWNiZTE2V29USHROOTVueXl3aDVFNHlPbzZJdEciLCJzY29wZSI6Im9wZW5pZCBwcm9maWxlIGVtYWlsIG1vZGVsLnJlYWQgbW9kZWwucmVxdWVzdCBvcmdhbml6YXRpb24ucmVhZCBvZmZsaW5lX2FjY2VzcyJ9.BZT29taF-Rk2jc0ogykyStz3K282tdGSsXkc5HmReAsYaNh_Rimx4ZCouawR_azzP1jlREZl_GRKwf0avYfLEfdfoGcHM_HOdav43C8dsAVLl-A_lVi1FD1cnQPaE8rkLAcKE-bd7S0WihCEmtqK2SRXI1ysnbsFpY3lUcjydjPXjO35bpoyx_Bd3sPl4oRP6tir_DsnG8gb-9dYj4u8cQYGE8PDpC8yliHVCJSt085ru_ElHXwA55bcvsAMOdDY0fPb7N4t95uDmXgaVaqOGkfB_GNM0He7Zseg9ZJlSLgT2qymfdkgWO63m3z2axWd-lsfp5_WXveqMSkr1i8g9A`
            }
        });

        console.log(response.data.choices[0].message.content);
        return response.data.choices[0].message.content;
        
    
    } catch (err) {
        console.log(err);
    }
}
export default sendGPTMessage;