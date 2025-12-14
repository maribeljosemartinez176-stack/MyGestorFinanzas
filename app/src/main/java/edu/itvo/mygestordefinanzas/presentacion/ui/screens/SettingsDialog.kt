package edu.itvo.mygestordefinanzas.presentacion.ui.screens

import androidx.compose.material3.*
import androidx.compose.foundation.layout.*
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.unit.dp

@Composable
fun SettingsDialog(
    isDarkTheme: Boolean,
    notificationsEnabled: Boolean,
    onThemeChange: (Boolean) -> Unit,
    onNotificationsChange: (Boolean) -> Unit,
    onDismiss: () -> Unit
) {
    AlertDialog(
        onDismissRequest = onDismiss,
        title = { Text("Configuración") },
        text = {
            Column(verticalArrangement = Arrangement.spacedBy(16.dp)) {

                Row(
                    verticalAlignment = Alignment.CenterVertically,
                    horizontalArrangement = Arrangement.SpaceBetween,
                    modifier = Modifier.fillMaxWidth()
                ) {
                    Text("Tema oscuro")
                    Switch(
                        checked = isDarkTheme,
                        onCheckedChange = {
                            onThemeChange(it)
                        }
                    )
                }

                Row(
                    verticalAlignment = Alignment.CenterVertically,
                    horizontalArrangement = Arrangement.SpaceBetween,
                    modifier = Modifier.fillMaxWidth()
                ) {
                    Text("Recibir notificaciones")
                    Switch(
                        checked = notificationsEnabled,
                        onCheckedChange = onNotificationsChange
                    )
                }
            }
        },
        confirmButton = {
            TextButton(onClick = onDismiss) {
                Text("Cerrar")
            }
        }
    )
}
